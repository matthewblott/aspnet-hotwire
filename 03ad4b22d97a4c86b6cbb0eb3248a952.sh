function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}
ps 67340;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 67340 > /dev/null;
done;
for child in $(list_child_processes 67696);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/Matt/Develop/lab/aspnet-hotwire/03ad4b22d97a4c86b6cbb0eb3248a952.sh;
