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
ps 53460;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 53460 > /dev/null;
done;
for child in $(list_child_processes 53473);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/Matt/Develop/lab/aspnet-hotwire/b75696567a144c0bbcbb9469e9b3e0fc.sh;
