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
ps 56838;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 56838 > /dev/null;
done;
for child in $(list_child_processes 56861);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/Matt/Develop/lab/aspnet-hotwire/d4f5a1e5afe7497c8234143d1af213e5.sh;
