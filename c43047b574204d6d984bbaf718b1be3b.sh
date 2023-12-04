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
ps 53995;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 53995 > /dev/null;
done;
for child in $(list_child_processes 54019);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/Matt/Develop/lab/aspnet-hotwire/c43047b574204d6d984bbaf718b1be3b.sh;
